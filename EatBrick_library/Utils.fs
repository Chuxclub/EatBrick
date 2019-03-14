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
    if kind = 0
    then AIR
    else
        if kind = 1
        then SIMPLE
        else   
            if kind = 2
            then DOUBLE
            else
                if kind = 3
                then TRIPLE
                else
                    if kind = 4
                    then NEWBALL
                    else
                        if kind = 5
                        then MODIFBALL
                        else
                            if kind = 6
                            then PADINCR
                            else
                                if kind = 7
                                then PADDECR
                                else
                                    if kind = 8
                                    then PADRESET
                                    else
                                        if kind = 9
                                        then SOLID
                                        else failwith("Pas de type !")
;;



let load_brick(brick_info : int array) : t_brick =
   
    let x : float ref = ref (float_of_int(brick_info.[0]) * SCREEN_WIDTH / 15.) in
    let y : float ref = ref (float_of_int(brick_info.[1]) * SCREEN_HEIGHT / 19.) in
    let bkind : t_brick_kind ref = ref(brick_kind_of_int(brick_info.[2])) in

    let brick : t_brick = { pos = { x = x; y = y; }; bkind = bkind; } in

    brick
;;

let rec load_bricks(blocks : int array list) : t_brick list =
    if len(blocks) = 0
    then []

    else 
        (
            let previous_brick : t_brick = load_brick( fst(blocks) ) in
            add_lst( load_bricks(rem_fst(blocks)), previous_brick )
        )
;;

let create_pad() : t_pad =
    let pad : t_pad = { width = ref(PAD_DEFAULT_SIZE); loc = ref(SCREEN_WIDTH / 2.);} in
    pad
;;

let make_eatbrick(filename : string) : t_eatbrick = 
    let world_bricks : t_brick list ref = ref(load_bricks(load_eatbrick_level(filename))) in
    let world_ball : t_ball list ref = ref( add_fst([], make_ball(0., 0.)) ) in
    let world_pad : t_pad = create_pad() in
    let intial_score : int ref = ref(0) in

    let eatbrick_world : t_eatbrick = {pad = world_pad; balls = world_ball; bricks = world_bricks; score = intial_score; } in

    eatbrick_world
;;

let make_eatbrick_demo() : t_eatbrick = 
    let world_bricks : t_brick list ref = ref(load_bricks(demo_level_eatbricks)) in
    let world_ball : t_ball list ref = ref( add_fst([], make_ball(SCREEN_WIDTH / 2., SCREEN_HEIGHT / 2.)) ) in
    let world_pad : t_pad = create_pad() in
    let intial_score : int ref = ref(0) in

    let eatbrick_world : t_eatbrick = {pad = world_pad; balls = world_ball; bricks = world_bricks; score = intial_score; } in

    eatbrick_world
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
