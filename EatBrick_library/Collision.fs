﻿module Collision


open Constantes
open Conception
open APICompProg
open Utils


let compute_bounding_box_pad (pad : t_pad) : t_rectangle =
  
  let xmin : float = !(pad.loc) - 0.5 * float_of_int( !(pad.width) ) in
  let xmax : float = !(pad.loc) + 0.5 * float_of_int( !(pad.width) ) in
  let ymin : float = float_of_int( PAD_INDEX_ROW + BRICK_HEIGHT ) in
  let ymax : float = float_of_int( PAD_INDEX_ROW ) in
  
  {
    xmin = xmin;
    ymin = ymin;
    xmax = xmax;
    ymax = ymax;
  }

;;

let compute_bounding_box_ball (ball : t_ball) : t_rectangle =
  
  let xmin : float = !(ball.pos.x) - int_of_ball_size(ball) / 2.  in
  let xmax : float = !(ball.pos.x) + int_of_ball_size(ball) / 2.  in
  let ymin : float = !(ball.pos.y) - int_of_ball_size(ball) / 2.  in
  let ymax : float = !(ball.pos.y) + int_of_ball_size(ball) / 2.  in
  
  {
    xmin = xmin;
    ymin = ymin;
    xmax = xmax;
    ymax = ymax;
  }
;;

let compute_bounding_box_brick(brick : t_brick) : t_rectangle =
    failwith "Not yet implemented!"
;;

let is_inside_rectangle (p : t_point, r : t_rectangle) : bool =

  !(p.x) >= r.xmin && !(p.x) <= r.xmax && !(p.y) >= r.ymax && !(p.y) <= r.ymin
;;


// Obligatoire
let is_overlap_a_in_b (a : t_rectangle, b : t_rectangle) : bool =

  let rect_xmin : float ref = ref(a.xmin)  in
  let rect_xmax : float ref = ref(a.xmax)  in
  let rect_ymin : float ref = ref(a.ymin)  in
  let rect_ymax : float ref = ref(a.ymax)  in

  let corner1 : t_point = {x = rect_xmin; y = rect_ymax;} in
  let corner2 : t_point = {x = rect_xmax; y = rect_ymax;} in
  let corner3 : t_point = {x = rect_xmin; y = rect_ymin;} in
  let corner4 : t_point = {x = rect_xmin; y = rect_ymax;} in  

  is_inside_rectangle(corner1, b) || is_inside_rectangle(corner2, b) ||
  is_inside_rectangle(corner3, b) || is_inside_rectangle(corner4, b)
;;

let is_overlap_b_in_a (a : t_rectangle, b : t_rectangle) : bool =

  let rect_xmin : float ref = ref(b.xmin)  in
  let rect_xmax : float ref = ref(b.xmax)  in
  let rect_ymin : float ref = ref(b.ymin)  in
  let rect_ymax : float ref = ref(b.ymax)  in

  let corner1 : t_point = {x = rect_xmin; y = rect_ymax;} in
  let corner2 : t_point = {x = rect_xmax; y = rect_ymax;} in
  let corner3 : t_point = {x = rect_xmin; y = rect_ymin;} in
  let corner4 : t_point = {x = rect_xmin; y = rect_ymax;} in  

  is_inside_rectangle(corner1, a) || is_inside_rectangle(corner2, a) ||
  is_inside_rectangle(corner3, a) || is_inside_rectangle(corner4, a)
;;

let is_overlap_rectangles (a : t_rectangle, b : t_rectangle) : bool =

  is_overlap_a_in_b(a, b) || is_overlap_b_in_a(a, b)
;;

// Obligatoire
let bounce_bound_screen(ball : t_ball) : unit =
    ()
;;

// Obligatoire
let collision_ball_pad(eatbrick : t_eatbrick, ball : t_ball ) : unit =
    ()
;;
        
// Obligatoire
let is_ball_lost(ball : t_ball) : bool =
    false
;;


// Pratique
let collision_ball_brick(ball : t_ball, brick : t_brick, eatbrick : t_eatbrick) : unit =
    ()
 ;;


// Obligatoire  
let collision_ball_bricks(ball : t_ball, bricks : t_brick list, eatbrick : t_eatbrick) : unit =
    ()
;;