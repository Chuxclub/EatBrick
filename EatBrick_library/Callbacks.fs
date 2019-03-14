module Callbacks

open Conception
open APICompProg
open Collision
open Constantes
open Helpers


let remove_dead_balls(balls : t_ball list) : t_ball list =
    balls
;;

let animate_ball(eatbrick : t_eatbrick, ball : t_ball) : unit =
    (
    ball.pos.x := ((!ball.pos.x) + ((!ball.speed.dx) ) *  !COEF_SPEED );
    ball.pos.y := ((!ball.pos.y) + ((!ball.speed.dy) ) *  !COEF_SPEED );
    )
;;

let check_gameover(eatbrick : t_eatbrick) : bool =
    false
;;

let leftclick() : unit =
    speed_game_greater() 
;;
let rightclick() : unit =
    speed_game_lower()
;;