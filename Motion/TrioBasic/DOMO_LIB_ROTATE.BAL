DEFCONST rotate_default_speed 180
DEFCONST rotate_default_creep 10


FUNCTION config_rotate_axis()
    BASE(axis_rotate)
    UNITS = 1000

    SPEED = rotate_default_speed
    CREEP = rotate_default_creep

    ACCEL = SPEED *1000
    DECEL = SPEED *1000
    FASTDEC = SPEED *1000

    REP_DIST = 180
    REP_OPTION = 0

    DATUM_IN = in_rotate_home

    SERVO = ON
ENDFUNC

FUNCTION rotate_axis_home() AS INTEGER
    DATUM(4) AXIS(axis_rotate)
    WAIT IDLE AXIS(axis_rotate)
    RETURN result_ok
ENDFUNC

FUNCTION rotate_axis_move(spd AS FLOAT, pos AS FLOAT) AS INTEGER
    SPEED AXIS(axis_rotate) = spd
    MOVEABS(pos) AXIS(axis_rotate)
    WAIT IDLE AXIS(axis_rotate)
    RETURN result_ok
ENDFUNC

FUNCTION rotate_axis_swing(spd AS FLOAT, pos1 AS FLOAT, pos2 AS FLOAT, count AS INTEGER) AS INTEGER

    SPEED AXIS(axis_rotate) = spd
    vr_rotate_swing_count = 0

    WHILE vr_rotate_swing_count < count
        MOVEABS(pos1)
        MOVEABS(pos2)
        WAIT IDLE AXIS(axis_rotate)
        vr_rotate_swing_count = vr_rotate_swing_count + 1
    WEND

    WAIT IDLE AXIS(axis_rotate)
    RETURN result_ok
ENDFUNC

