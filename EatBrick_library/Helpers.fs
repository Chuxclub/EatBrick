module Helpers

open System
open System.IO

open APICompProg
open Constantes

let speed_game_greater() : unit =
    COEF_SPEED := !COEF_SPEED + 1.
;;

let speed_game_lower() : unit =
    COEF_SPEED := !COEF_SPEED - 1.
;;

let demo_level_eatbricks : int array list = 
    [
       [| 0; 0; 0|]
       [| 2; 0; 1|]
       [| 4; 0; 2|]
       [| 6; 0; 3|]
       [| 8; 0; 4|]
       [| 10; 0; 5|]
       [| 12; 0; 6|]
       [| 14; 0; 7|]
       [| 15; 2; 8|]
       [| 13; 2; 9|]
       [| 11; 2; 0|]
       [| 9; 2; 1|]
       [| 7; 2; 2|]
       [| 5; 2; 3|]
       [| 3; 2; 4|]
       [| 1; 2; 5|]
       [| 0; 4; 6|]
       [| 2; 4; 7|]
       [| 4; 4; 8|]
       [| 6; 4; 9|]
       [| 8; 4; 0|]
       [| 10; 4; 1|]
       [| 12; 4; 2|]
       [| 14; 4; 3|]
       [| 15; 6; 4|]
       [| 13; 6; 5|]
       [| 11; 6; 6|]
       [| 9; 6; 7|]
       [| 7; 6; 8|]
       [| 5; 6; 9|]
       [| 3; 6; 0|]
       [| 1; 6; 1|]
       [| 0; 8; 2|]
       [| 2; 8; 3|]
       [| 4; 8; 4|]
       [| 6; 8; 5|]
       [| 8; 8; 6|]
       [| 10; 8; 7|]
       [| 12; 8; 8|]
       [| 14; 8; 9|]
    ]
;;


(*
    NE PAS REGARDER CETTE FONCTION.
    Contient des éléments trop avancées par rapport à AP1 et CP.
*)
let load_eatbrick_level(filename : string) : int array list =
    let world = File.ReadAllLines(filename) in
    let size = arr_len(world) in
    let res = ref [] in
    let brick_line : string ref = ref ("") in
    let brick_info : string array ref = ref [|" "; " "; " ";|] in
    for i= 0 to size - 1 do
        brick_line := world.[i] ;
        brick_info := (!brick_line).Split(' ') ;
        res := add_fst(!res, Array.map (fun x -> int(x)) !brick_info)
    done;
    !res
;;