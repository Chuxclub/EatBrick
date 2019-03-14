module Conception


type t_ball_size = SMALL | NORMAL | LARGE

type t_ball_kind = CLASSIC | GLUE | STRONG

type t_brick_kind = 
    AIR
    | SIMPLE | DOUBLE | TRIPLE
    | NEWBALL | MODIFBALL
    | PADINCR | PADDECR | PADRESET
    | SOLID

type t_point = { x : float ref ; y : float ref }

type t_vector = { dx : float ref ; dy : float ref }

type t_ball = {
    pos : t_point;
    speed : t_vector;
    size : t_ball_size ref;
    kind : t_ball_kind ref
}

type t_pad = {
    loc : float ref;
    width : int ref;
}

type t_brick = {
    pos : t_point;
    bkind : t_brick_kind ref;
}

type t_eatbrick = {
    pad : t_pad;
    balls : t_ball list ref;
    bricks : t_brick list ref;
    score : int ref;
}

type t_rectangle =
  {
    xmin : float;
    ymin : float;
    xmax : float;
    ymax : float;
  }