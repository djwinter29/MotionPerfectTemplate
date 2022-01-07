
DEFCONST sim_cfg_liner_top -1.2
DEFCONST sim_cfg_liner_mid 20.3
DEFCONST sim_cfg_liner_base 100
DEFCONST sim_cfg_liner_sensor_width 1.2

DEFCONST sim_cfg_rotate_home -1
DEFCONST sim_cfg_rotate_sensor_width 2

' clear the postion
BASE(0)
DEFPOS(0,0)


WHILE TRUE
    linepos = MPOS AXIS(axis_liner)

    IF (linepos >= sim_cfg_liner_top) AND (linepos < (sim_cfg_liner_top + sim_cfg_liner_sensor_width)) THEN
        OP(in_liner_top,OFF)
        OP(in_liner_middle,ON)
        OP(in_liner_base,ON)
    ELSEIF (linepos >= sim_cfg_liner_mid) AND (linepos < (sim_cfg_liner_mid + sim_cfg_liner_sensor_width)) THEN
        OP(in_liner_top,ON)
        OP(in_liner_middle,OFF)
        OP(in_liner_base,ON)
    ELSEIF (linepos >= sim_cfg_liner_base) AND (linepos < (sim_cfg_liner_base + sim_cfg_liner_sensor_width)) THEN
        OP(in_liner_top,ON)
        OP(in_liner_middle,ON)
        OP(in_liner_base,OFF)
    ELSE
        OP(in_liner_top,ON)
        OP(in_liner_middle,ON)
        OP(in_liner_base,ON)
    ENDIF

    rotatepos = MPOS AXIS(axis_rotate)
    IF (rotatepos >= sim_cfg_rotate_home) AND (rotatepos < (sim_cfg_rotate_home + sim_cfg_rotate_sensor_width)) THEN
        OP(in_rotate_home,OFF)
    ELSE
        OP(in_rotate_home,ON)
    ENDIF

    WA(1)
WEND
