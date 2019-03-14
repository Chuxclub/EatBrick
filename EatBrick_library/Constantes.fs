module Constantes

[<Literal>]
let BRICK_HEIGHT = 25

[<Literal>]
let BRICK_WIDTH = 50

[<Literal>]
let SCREEN_WIDTH = 800.

[<Literal>]
let SCREEN_HEIGHT = 500.

[<Literal>]
let BALL_SIZE_SMALL = 5.0
[<Literal>]
let BALL_SIZE_NORMAL = 15.
[<Literal>]
let BALL_SIZE_LARGE = 30.

[<Literal>]
let PAD_DEFAULT_SIZE = 150

(* indique la couche sur laquelle apparait le pad *)
[<Literal>]
let PAD_INDEX_ROW = 18


let PAD_TOP_Y = (PAD_INDEX_ROW * BRICK_HEIGHT)

let BALL_TOP_LOSE = (PAD_INDEX_ROW + 1) * BRICK_HEIGHT

// AVANCEMENT DU COEFFICIENT DE VITESSE
let COEF_SPEED =  ref 2.
