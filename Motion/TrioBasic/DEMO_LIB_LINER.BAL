DEFCONST liner_default_speed 10
DEFCONST liner_default_creep 1

FUNCTION config_liner_axis()
    BASE(axis_liner)
    UNITS = 1000

    SPEED = liner_default_speed
    CREEP = liner_default_creep

    ACCEL = SPEED *100
    DECEL = SPEED *100
    FASTDEC = SPEED *100

    REP_DIST = 200000000
    REP_OPTION = 0

    DATUM_IN = in_liner_top
    FWD_IN = in_liner_base
    REV_IN = in_liner_top

    SERVO = ON
ENDFUNC


FUNCTION liner_axis_home() AS INTEGER
    SPEED AXIS(axis_liner) = liner_default_speed
    CREEP AXIS(axis_liner) = liner_default_creep

    REV_IN = -1

    DATUM(4) AXIS(axis_liner)
    WAIT IDLE AXIS(axis_liner)
    ' set reverse limit
    REV_IN = DATUM_IN

    FORWARD AXIS(axis_liner)
    WAIT UNTIL IN(in_liner_middle)= OFF
    vr_liner_middle_sensor_pos = MPOS AXIS(axis_liner)

    WAIT IDLE AXIS(axis_liner)
    vr_liner_base_pos= MPOS AXIS(axis_liner)

    REVERSE AXIS(axis_liner)
    WAIT IDLE AXIS(axis_liner)
    RETURN result_ok
ENDFUNC

FUNCTION liner_axis_move(spd AS FLOAT, pos AS FLOAT) AS INTEGER
    SPEED AXIS(axis_liner) = spd
    MOVEABS(pos) AXIS(axis_liner)
    WAIT IDLE AXIS(axis_liner)
    RETURN result_ok
ENDFUNC

FUNCTION liner_axis_move_top(spd AS FLOAT) AS INTEGER
    SPEED AXIS(axis_liner) = spd
    REVERSE AXIS(axis_liner)
    WAIT IDLE AXIS(axis_liner)
    RETURN result_ok
ENDFUNC

FUNCTION liner_axis_move_middle(spd AS FLOAT) AS INTEGER
    SPEED AXIS(axis_liner) = spd
    MOVEABS(vr_liner_middle_sensor_pos) AXIS(axis_liner)
    WAIT IDLE AXIS(axis_liner)
    RETURN result_ok
ENDFUNC

FUNCTION liner_axis_move_base(spd AS FLOAT) AS INTEGER
    SPEED AXIS(axis_liner) = spd
    FORWARD AXIS(axis_liner)
    WAIT IDLE AXIS(axis_liner)
    RETURN result_ok
ENDFUNC

