'****************************************************************
'*** VR defines
' VR 1000 ~ 2000 : input int16
' VR 2000 ~ 2500 : input int32
' VR 2500 ~ 3000 : input float
' VR 3000 ~ 4000 : output int16
' VR 4000 ~ 4500 : output int32
' VR 4500 ~ 5000 : output float
' VR 5000 ~ 5400 : protocol int16
' VR 5500 ~ 6000 : protocol float
'****************************************************************
GLOBAL "vr_rotate_swing_count",4000

GLOBAL "vr_liner_middle_sensor_pos",4500
GLOBAL "vr_liner_base_pos",4501

GLOBAL "vr_liner_motor_speed",4550
GLOBAL "vr_liner_motor_pos",4551
GLOBAL "vr_rotate_motor_speed",4552
GLOBAL "vr_rotate_motor_pos",4553

'****************************************************************
'*** Constant
'****************************************************************
CONSTANT "axis_liner", 0
CONSTANT "axis_rotate", 1

CONSTANT "in_liner_top", 0
CONSTANT "in_liner_middle", 1
CONSTANT "in_liner_base", 2
CONSTANT "in_rotate_home", 3

CONSTANT "result_ok",0
CONSTANT "result_not_implemented",999

' Test Framework (VR Addresses)
' 5000 ~ 5399(int16)
GLOBAL "vr_run_request", 5000
GLOBAL "vr_run_completed", 5001
GLOBAL "vr_run_routine", 5002
GLOBAL "vr_run_cancel", 5003
GLOBAL "vr_max_history_count", 5004
GLOBAL "vr_max_parameter_count", 5005
' 5400 ~ 5499(int16) : value not exposed


' 5000 ~ 3499(int16)
CONSTANT "last_run_count_addr_start", 5010 ' Max record 10 result
CONSTANT "last_run_routine_addr_start", 5020
CONSTANT "last_run_result_addr_start", 5030
' 5500 ~ 5999(float)
CONSTANT "run_parameter_addr_start", 5500
CONSTANT "last_run_time_addr_start", 5510


PRINT "System started at: "; DATE$; " "; TIME$


WDOG = OFF

'****************************************************************
' Skip if it is a Simulator
'****************************************************************
IF CONTROL = 400 THEN
    ' Start Axis simulation
    RUN "SIMULATOR"
ELSE
    ' Set so that Emergency Messages from RTA drives don't cause WDOG to go off
    ETHERCAT($E0, 0, 1) ' Set Emergency Message control

    ' Master Trio config for the RTA drives, specifically DC shift time below
    ' Adjust the communication jitter as per section 3.3.3 of the RTA doc
    ETHERCAT($91, -1, 1000 * SERVO_PERIOD + 300) ' DC shift time + 300uS

    ETHERCAT(0,0) ' start the ETHERCAT net
    UNIT_CLEAR ' clear system error once in OPERATIONAL state
ENDIF

RUN "DIAGNOSTICS"

' need to move to statemachine
WDOG = ON

' Initialization
config_liner_axis()
config_rotate_axis()

init_protocol()

WHILE TRUE

    run_protocol()

    WA(1)
WEND



