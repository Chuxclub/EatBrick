module Utils

open APICompProg

open Conception
open Constantes
open Helpers

let ball_size(ball : t_ball) : float =
    BALL_SIZE_NORMAL
;;

let make_ball(px : float, py : float) : t_ball =
    let p = { x = ref px; y = ref py } in
    let v = {  dx = ref 1.; dy = ref -1. } in
    { pos = p; speed = v; size=ref NORMAL; kind= ref CLASSIC }
;;

let make_rectangle(xmin : float, ymin : float, xmax : float, ymax : float) : t_rectangle =
    { 
    xmin = xmin;
    ymin = ymin;
    xmax = xmax;
    ymax = ymax;
    }
;;


let brick_kind_of_int(kind : int) : t_brick_kind =
    failwith "Not yet implemented"
;;



let load_brick(brick_info : int array) : t_brick =
    failwith "Not yet implemented!"
;;

let rec load_bricks(blocks : int array list) : t_brick list =
    []
;;

let make_eatbrick(filename : string) : t_eatbrick = 
    failwith "Not yet implemented!"
;;


let make_eatbrick_demo() : t_eatbrick   = 
    failwith "Not yet implemented!"
;;

let int_of_ball_size (ball : t_ball) : float =
    if !(ball.size) = SMALL
    then BALL_SIZE_SMALL
    else
        if !(ball.size) = NORMAL
        then BALL_SIZE_NORMAL
        else
            if !(ball.size) = LARGE
            then BALL_SIZE_LARGE
            else failwith ("pas de taille !")
;;
