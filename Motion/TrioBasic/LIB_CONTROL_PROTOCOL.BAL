' Configuration
DEFCONST maxparacount 4 ' max is 10
DEFCONST maxhistorycount 3 ' max is 10

FUNCTION init_protocol()
    ' Initialize the state value
    vr_run_request = 0
    vr_run_completed = 0
    vr_max_history_count = maxhistorycount
    vr_max_parameter_count = maxparacount

    'Start Ethernet port section
    ' Configure the endpont to be ModBus Client with connect maanagement as TCP Server
    ' Modbus TCP port number
    ETHERNET(1,-1,10,502) ' As TCP Server listening on port 502
    ETHERNET(1,-1,14,0,7,-1)' cancel all previous map

    ' Input to controller
    ETHERNET(1,-1,14,0,7,10000,1000,1000,0,0) ' VRs 1000 to 1999 size = Int 16 Modbus address 10000~10999
    ETHERNET(1,-1,14,0,7,11000,2000,500,0,1) ' VRs 2000 to 2499 size = Int 32 Modbus address 11000~11999
    ETHERNET(1,-1,14,0,7,12000,2500,500,0,2) ' VRs 2500 to 2999 size = float 32 Modbus address 12000~12999
    ' Output to external
    ETHERNET(1,-1,14,0,7,20000,3000,1000,0,0) ' VRs 3000 to 3999 size = Int 16 Modbus address 20000~20999
    ETHERNET(1,-1,14,0,7,21000,4000,500,0,1) ' VRs 4000 to 4499 size = Int 32 Modbus address 21000~21999
    ETHERNET(1,-1,14,0,7,22000,4500,500,0,2) ' VRs 4500 to 4999 size = float 32 Modbus address 22000~22999

    ' Used for test framework controls, input and output is mixed in the region
    ETHERNET(1,-1,14,0,7,30000,5000,400,0,0) ' VRs 5000 to 5399 size = Int 16 Modbus address 30000~30399
    ETHERNET(1,-1,14,0,7,31000,5500,500,0,2) ' VRs 5500 to 5999 size = float 32 Modbus address 31000~21499

    'PRINT "Modbus Mapping :"
    'ETHERNET(0,-1,14,0,7) ' display the map to terminal #0

    ' Enable comm port after the settings were applied
    ' A Corresponding IP_PROTOCOL_CTRL=12 command should be present in the MC_CONFIG program
    IP_PROTOCOL_CTRL = 0

ENDFUNC

FUNCTION run_protocol()
    IF (vr_run_request <> vr_run_completed) THEN
        DIM para AS FLOAT(maxparacount)

        starttime = TICKS
        ' Copy paramters
        FOR i = 0 TO (maxparacount-1)
            para(i) = VR(run_parameter_addr_start + i)
        NEXT i
        ' Run the routine
        run_result = run_routine(vr_run_routine, para(0), para(1), para(2), para(3))
        ' Calculate run time
        run_duration = starttime - TICKS

        PRINT INT(vr_run_request); ": Routine ";INT(vr_run_routine);" completed in ";run_duration;" ms"

        ' Update the run history
        FOR i = (maxhistorycount - 1) TO 1 STEP -1
            VR(last_run_count_addr_start + i) = VR(last_run_count_addr_start + i - 1)
            VR(last_run_routine_addr_start + i) = VR(last_run_routine_addr_start + i - 1)
            VR(last_run_result_addr_start + i) = VR(last_run_result_addr_start + i - 1)
            VR(last_run_time_addr_start + i) = VR(last_run_time_addr_start + i - 1)
        NEXT i
        VR(last_run_count_addr_start) = vr_run_request ' last run count
        VR(last_run_routine_addr_start) = vr_run_routine ' last routine
        VR(last_run_result_addr_start) = run_result
        VR(last_run_time_addr_start) = run_duration

        ' TODO: Reset machine status if needed
        'IF run_result = FALSE THEN
        'Reset Reset Reset !!!!
        'ENDIF

        ' Completed
        vr_run_completed = vr_run_request
    ENDIF
ENDFUNC





FUNCTION run_routine(rt AS INTEGER, p0 AS FLOAT, p1 AS FLOAT, p2 AS FLOAT, p3 AS FLOAT)AS INTEGER
    DIM result AS INTEGER

    SELECT_CASE rt
        CASE 100
            result = liner_axis_home()
        CASE 101
            result = liner_axis_move(p0, p1)
        CASE 102
            result = liner_axis_move_top(p0)
        CASE 103
            result = liner_axis_move_middle(p0)
        CASE 104
            result = liner_axis_move_base(p0)
        CASE 200
            result = rotate_axis_home()
        CASE 201
            result = rotate_axis_move(p0, p1)
        CASE 202
            result = rotate_axis_swing(p0, p1, p2, p3)
        CASE ELSE
            PRINT "Unknown reqeust "; rt
            result = result_not_implemented
    END_CASE

    RETURN result
ENDFUNC
