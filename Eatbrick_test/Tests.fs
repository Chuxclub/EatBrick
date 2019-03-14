module Tests

open System
open Xunit

open Conception
open Utils
open Constantes
open APICompProg
open Helpers
open Collision


(* il faut convenir d'une convention de nommage
 peut etre Etape 1: puis le nom de la methode sous test 
 mais a voir selon les cas *)

[<Fact>]
let ``Check constants consistencies``() =
    let type_int32 = Type.GetType("System.Int32") in
    let type_float = Type.GetType("System.Double") in
    let floatref : float ref = ref 2. in
    (* Verification des types de donnees, vous ne devez pas les modifier *)
    Assert.IsAssignableFrom(type_int32, BRICK_HEIGHT);
    Assert.IsAssignableFrom(type_int32, BRICK_WIDTH);
    Assert.IsAssignableFrom(type_float, SCREEN_WIDTH);
    Assert.IsAssignableFrom(type_float, SCREEN_HEIGHT);
    Assert.IsAssignableFrom(type_float, BALL_SIZE_SMALL);
    Assert.IsAssignableFrom(type_float, BALL_SIZE_NORMAL);
    Assert.IsAssignableFrom(type_float, BALL_SIZE_LARGE);
    Assert.IsAssignableFrom(type_int32, PAD_DEFAULT_SIZE);
    Assert.IsAssignableFrom(type_int32, PAD_INDEX_ROW);
    Assert.IsAssignableFrom(type_int32, PAD_TOP_Y);
    Assert.IsAssignableFrom(type_int32, BALL_TOP_LOSE);
    Assert.IsAssignableFrom(floatref.GetType(), COEF_SPEED);
    
    (* Verification de la coherence des valeurs pour la communication avec la vue *)
    Assert.True(BRICK_HEIGHT > 0);
    Assert.True(float_of_int(BRICK_HEIGHT) > BALL_SIZE_NORMAL);
    Assert.True(BRICK_WIDTH > 0);
    Assert.True(float_of_int(BRICK_WIDTH) > BALL_SIZE_NORMAL);

    Assert.Equal(SCREEN_WIDTH, 800.);
    Assert.Equal(SCREEN_HEIGHT, 500.);
    
    Assert.True(BALL_SIZE_SMALL > 3.);
    Assert.True(BALL_SIZE_SMALL < BALL_SIZE_NORMAL);
    Assert.True(BALL_SIZE_NORMAL < BALL_SIZE_LARGE);
    Assert.True(BALL_SIZE_LARGE > float_of_int(BRICK_HEIGHT));
    Assert.True(17 <= PAD_INDEX_ROW && PAD_INDEX_ROW <= 19);
    Assert.Equal(PAD_TOP_Y, PAD_INDEX_ROW * BRICK_HEIGHT);
    Assert.Equal((PAD_INDEX_ROW + 1) * BRICK_HEIGHT , BALL_TOP_LOSE);

    Assert.True(0. < !COEF_SPEED)
;;



// a faire par etudiants
[<Fact>]
let ``Convert int to t_brick_kind`` ()  =
    Assert.Equal(brick_kind_of_int(0), AIR);
    Assert.Equal(brick_kind_of_int(1), SIMPLE);
    Assert.Equal(brick_kind_of_int(2), DOUBLE);
    Assert.Equal(brick_kind_of_int(3), TRIPLE);
    Assert.Equal(brick_kind_of_int(4), NEWBALL);
    Assert.Equal(brick_kind_of_int(5), MODIFBALL);
    Assert.Equal(brick_kind_of_int(6), PADINCR);
    Assert.Equal(brick_kind_of_int(7), PADDECR);
    Assert.Equal(brick_kind_of_int(8), PADRESET);
    Assert.Equal(brick_kind_of_int(9), SOLID);
    Assert.Equal(brick_kind_of_int(10), AIR);
    Assert.Equal(brick_kind_of_int(-1), AIR)
;;


[<Fact>]
let ``load_brick from wrong int array length`` () =
    try 
        let brick : t_brick = load_brick([| 0;0;0;0 |]) in
        Assert.True(false)
    with
    | Failure(msg) -> Assert.True(true)
;;


// a faire par etudiants
[<Fact>]
let ``load_brick from int array`` ()  =
    let brick : t_brick = load_brick([| 1; 2; 3 |]) in
    Assert.Equal(!brick.bkind, TRIPLE);
    Assert.Equal(!brick.pos.x, float_of_int(BRICK_WIDTH * 1));
    Assert.Equal(!brick.pos.y, float_of_int(BRICK_HEIGHT * 2));
;;


// a faire par etudiants: tester la recursivite
[<Fact>]
let ``load_bricks from multiples bricks`` ()  =
    let demo0 : int array list = [ ] in
    let demo1 : int array list = [ [| 1;2;3 |] ] in
    let demo2 : int array list = [ [| 1;2;3 |] ; [|4;5;6|] ] in
    let demo3 : int array list = [ [| 1;2;3 |] ; [|4;5;6|] ; [|7;8;9|] ] in
    let bricks0 : t_brick list = load_bricks(demo0) in
    Assert.Equal(len(bricks0) , 0);
    let bricks1 : t_brick list = load_bricks(demo1) in
    Assert.Equal(len(bricks1) , 1);
    let bricks2 : t_brick list = load_bricks(demo2) in
    Assert.Equal(len(bricks2) , 2);
    let bricks3 : t_brick list = load_bricks(demo3) in
    Assert.Equal(len(bricks3) , 3)
;;

// a faire par etudiants
[<Fact>]
let ``Create ball`` () =
    let ball : t_ball = make_ball(1.,2.) in
    Assert.Equal(!ball.pos.x, 1.);
    Assert.Equal(!ball.pos.y, 2.);
    Assert.Equal(!ball.kind, CLASSIC);
    Assert.Equal(!ball.speed.dx, 1.);
    Assert.Equal(!ball.speed.dy, -1.);
    Assert.Equal(!ball.size, NORMAL)
;;

// a faire par etudiants
[<Fact>]
let ``Convert t_ball_size to float`` () =
    let ball : t_ball = make_ball(1.,2.) in
    ball.size := SMALL;
    let s = ball_size(ball) in
    Assert.Equal(s,BALL_SIZE_SMALL);
    ball.size := NORMAL;
    let m = ball_size(ball) in
    Assert.Equal(m, BALL_SIZE_NORMAL);
    ball.size := LARGE;
    let l = ball_size(ball) in
    Assert.Equal(l, BALL_SIZE_LARGE)
;;

// a faire par etudiants
[<Fact>]
let ``Create eatbrick demo`` () =
    let eatbrick : t_eatbrick = make_eatbrick_demo() in
    Assert.Equal(len(!eatbrick.bricks), 40); (* TODO trop precis? *)
    Assert.Equal(len(!eatbrick.balls) , 1);
    Assert.Equal(!eatbrick.score, 0);
    (* TODO: ajoutez d'autre test? larg pad? pos/vit de la balle? ... *)
;;


[<Fact>]
let ``Helpers functions (not yours by default)`` () =
    let backup : float = !COEF_SPEED in
    speed_game_greater();
    Assert.True(!COEF_SPEED >= backup);
    let modif : float = !COEF_SPEED in
    speed_game_lower();
    Assert.True(!COEF_SPEED <= modif);
    COEF_SPEED := backup; (* restauration de l'etat de la memoire: postambule *)
;;

[<Fact>]
let ``Test is_inside_rectangle`` () =
    let rect : t_rectangle = make_rectangle(1.,1.,4.,3.) in
    let p0 : t_point = { x = ref 0.; y = ref 0. } in
    let p1 : t_point = { x = ref 1.; y = ref 1. } in
    let p2 : t_point = { x = ref 2.; y = ref 2. } in
    Assert.False(is_inside_rectangle(p0,rect));
    Assert.True(is_inside_rectangle(p1,rect));
    Assert.True(is_inside_rectangle(p2,rect))
;;

[<Fact>]
let ``Test is_overlap_rectangles`` () =
    let rect : t_rectangle = make_rectangle(1.,1.,4.,3.)in
    let rect0 : t_rectangle = make_rectangle(0.,0.,1.,1.) in
    let rect1 : t_rectangle = make_rectangle(2.,2.,5.,6.) in
    let rect2 : t_rectangle = make_rectangle(20.,20.,50.,60.) in
    Assert.True(is_overlap_rectangles(rect, rect0));
    Assert.True(is_overlap_rectangles(rect, rect1));
    Assert.False(is_overlap_rectangles(rect, rect2));

    Assert.True(is_overlap_rectangles(rect0, rect));
    Assert.True(is_overlap_rectangles(rect1, rect));
    Assert.False(is_overlap_rectangles(rect2, rect))
;;

// bounce_bound_screen
[<Fact>]
let ``Test bounce_bound_screen ledt inbound`` () =
    let p : t_point = { x = ref 100. ; y = ref 100. } in
    let s : t_vector = { dx = ref -1.; dy = ref 0. } in
    let ball : t_ball = { pos = p; speed = s; size = ref NORMAL; kind = ref CLASSIC } in
    bounce_bound_screen(ball);
    Assert.Equal(!ball.speed.dx, -1.);
    Assert.Equal(!ball.speed.dy, 0.)
;;

[<Fact>]
let ``Test bounce_bound_screen top inbound`` () =
    let p : t_point = { x = ref 100. ; y = ref 100. } in
    let s : t_vector = { dx = ref 0.; dy = ref -1. } in
    let ball : t_ball = { pos = p; speed = s; size = ref NORMAL; kind = ref CLASSIC } in
    bounce_bound_screen(ball);
    Assert.Equal(!ball.speed.dy, 0.);
    Assert.Equal(!ball.speed.dx, -1.)
;;

[<Fact>]
let ``Test bounce_bound_screen right inbound`` () =
    let p : t_point = { x = ref 100. ; y = ref 100. } in
    let s : t_vector = { dx = ref 1.; dy = ref 0. } in
    let ball : t_ball = { pos = p; speed = s; size = ref NORMAL; kind = ref CLASSIC } in
    bounce_bound_screen(ball);
    Assert.Equal(!ball.speed.dx, 1.);
    Assert.Equal(!ball.speed.dy , 0.)
;;

[<Fact>]
let ``Test bounce_bound_screen bottom inbound`` () =
    let p : t_point = { x = ref 100. ; y = ref 100. } in
    let s : t_vector = { dx = ref 0.; dy = ref 1. } in
    let ball : t_ball = { pos = p; speed = s; size = ref NORMAL; kind = ref CLASSIC } in
    bounce_bound_screen(ball);
    Assert.Equal(!ball.speed.dy, 0.);
    Assert.Equal(!ball.speed.dx, -1.)
;;

[<Fact>]
let ``Test bounce_bound_screen left outbound`` () =
    let p : t_point = { x = ref -1. ; y = ref 100. } in
    let s : t_vector = { dx = ref -1.; dy = ref -1. } in
    let ball : t_ball = { pos = p; speed = s; size = ref NORMAL; kind = ref CLASSIC } in
    bounce_bound_screen(ball);
    Assert.True(!ball.speed.dx > 0.);
    Assert.True(!ball.speed.dy = -1.)
;;

[<Fact>]
let ``Test bounce_bound_screen top outbound`` () =
    let p : t_point = { x = ref 100. ; y = ref -1. } in
    let s : t_vector = { dx = ref -1.; dy = ref -1. } in
    let ball : t_ball = { pos = p; speed = s; size = ref NORMAL; kind = ref CLASSIC } in
    bounce_bound_screen(ball);
    Assert.True(!ball.speed.dy > 0.);
    Assert.Equal(!ball.speed.dx, -1.)
;;

[<Fact>]
let ``Test bounce_bound_screen right outbound`` () =
    let p : t_point = { x = ref SCREEN_WIDTH ; y = ref 100. } in
    let s : t_vector = { dx = ref -1.; dy = ref -1. } in
    let ball : t_ball = { pos = p; speed = s; size = ref NORMAL; kind = ref CLASSIC } in
    bounce_bound_screen(ball);
    Assert.True(!ball.speed.dx < 0.);
    Assert.True(!ball.speed.dy = -1.)
;;

[<Fact>]
let ``Test bounce_bound_screen bottom outbound`` () =
    let p : t_point = { x = ref 100. ; y = ref SCREEN_HEIGHT } in
    let s : t_vector = { dx = ref -1.; dy = ref 1. } in
    let ball : t_ball = { pos = p; speed = s; size = ref NORMAL; kind = ref CLASSIC } in
    bounce_bound_screen(ball);
    Assert.True(!ball.speed.dy < 0.);
    Assert.Equal(-1.,!ball.speed.dx)
;;

// is_ball_lost
[<Fact>]
let ``Test is_ball_lost true`` () =
    let p : t_point = { x = ref 100. ; y = ref SCREEN_HEIGHT } in
    let s : t_vector = { dx = ref -1.; dy = ref 1. } in
    let ball : t_ball = { pos = p; speed = s; size = ref NORMAL; kind = ref CLASSIC } in
    Assert.True(is_ball_lost(ball))
;;

[<Fact>]
let ``Test is_ball_lost false`` () =
    let p : t_point = { x = ref 100. ; y = ref 100. } in
    let s : t_vector = { dx = ref -1.; dy = ref 1. } in
    let ball : t_ball = { pos = p; speed = s; size = ref NORMAL; kind = ref CLASSIC } in
    Assert.False(is_ball_lost(ball))
;;


(*  
    (* FONCTION DE TEST BONUS *)

[<Fact>]
let ``Bounce bonus count`` () =
    let backup = !count_bounce in
    Assert.Equal(!count_bounce, backup);
    let modif = count_bounce_add() in
    Assert.NotEqual(!count_bounce, backup);
    Assert.True(!count_bounce > backup);
    count_bounce_reset();
    Assert.Equal(!count_bounce, 0);
    let eatbrick : t_eatbrick = make_eatbrick_demo() in
    let ball : t_ball = nth(!eatbrick.balls,0) in
    ball.pos.x := !eatbrick.pad.loc;
    ball.pos.y := float_of_int(PAD_TOP_Y);
    (* fin de preparation du test *)
    collision_ball_pad(eatbrick,ball);
    Assert.Equal(!count_bounce, 0);
    count_bounce := backup
;;

[<Fact>]
let ``Score add`` () =
    let eatbrick : t_eatbrick = make_eatbrick_demo() in
    Assert.Equal(!eatbrick.score, 0);
    score_add(eatbrick);
    Assert.Equal(!eatbrick.score, !count_bounce);
;;

[<Fact>]
let ``Test compute bbox pad`` () =
    let eatbrick : t_eatbrick = make_eatbrick_demo() in
    let pad : t_pad = eatbrick.pad in
    let bbox : t_rectangle = compute_bounding_box_pad(pad) in
    Assert.Equal(bbox.xmax, !pad.loc + float_of_int(!pad.width / 2));
    Assert.Equal(bbox.ymin, float_of_int(PAD_TOP_Y) );
    Assert.Equal(bbox.xmin, !pad.loc - float_of_int(!pad.width / 2));
    Assert.Equal(bbox.ymax, float_of_int(PAD_TOP_Y + BRICK_HEIGHT));
;;

[<Fact>]
let ``Test compute_bounding_box_ball`` () =
    let eatbrick : t_eatbrick = make_eatbrick_demo() in
    let ball : t_ball = nth(!eatbrick.balls, 0) in 
    let bbox : t_rectangle = compute_bounding_box_ball(ball) in
    let size = ball_size(ball) in
    Assert.Equal(bbox.ymin, !ball.pos.y - size/2.);
    Assert.Equal(bbox.ymax, !ball.pos.y + size/2.);
    Assert.Equal(bbox.xmax, !ball.pos.x + size/2.);
    Assert.Equal(bbox.xmin, !ball.pos.x - size/2.);
;;

[<Fact>]
let ``Test compute_bounding_box_brick`` () =
    let eatbrik : t_eatbrick = make_eatbrick_demo() in
    let brick0 : t_brick = nth(!eatbrik.bricks, 0) in
    let bbox : t_rectangle = compute_bounding_box_brick(brick0) in
    Assert.Equal(bbox.xmin, 0.);
    Assert.Equal(bbox.ymin, 0.);
    Assert.Equal(bbox.xmax, float_of_int(BRICK_WIDTH));
    Assert.Equal(bbox.ymax, float_of_int(BRICK_HEIGHT))
;;

[<Fact>]
let ``Test delta_abs_pad leftmost`` () =
    let pad : t_pad = { loc = ref 125. ; width = ref 50 } in
    let x0 : float = 0. in
    let x1 : float = 105. in
    let x2 : float = 115. in
    let x3 : float = 125. in
    let x4 : float = 135. in
    let x5 : float = 145. in
    let x6 : float = 600. in
    Assert.Equal(-1.5, delta_abs_pad(pad,x0));
    Assert.Equal(-1.0, delta_abs_pad(pad,x1));
    Assert.Equal(-0.5, delta_abs_pad(pad,x2));
    Assert.Equal( 0.0, delta_abs_pad(pad,x3));
    Assert.Equal( 0.5, delta_abs_pad(pad,x4));
    Assert.Equal( 1.0, delta_abs_pad(pad,x5));
    Assert.Equal( 1.5, delta_abs_pad(pad,x6));
;;


// remove_dead_balls
// add_new_ball (pas sur)
// brick_hit x2 pour les simples puis les mysteres
// collision_ball_bricks
// check_gameover
// animate_ball

*)

