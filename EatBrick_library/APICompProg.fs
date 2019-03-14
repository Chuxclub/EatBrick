module APICompProg

open System


let rec same_list(a,b) =
    match (a,b) with
    |   ([],[]) -> true
    | (c::sa, d::sb) -> if c = d then same_list(sa,sb) else false
    | (_,_) -> false
;;

let len(l) = List.length l;;

let fst(l) =
  match l with
    [] -> failwith "error empty list"
  | hd::tail -> hd
;;

let rec lst(l) =
  match l with
    [] -> failwith "error empty list"
  | hd::[] -> hd
  | hd::tail -> lst(tail)
;;

let rec nth(l,k) =
  match (l,k) with
    ([],_) -> if (k<0)
              then failwith "error index must be positive"
              else failwith "error list is too short"
  | (hd::tail,0) -> hd
  | (hd::tail,k) -> if (k<0) then failwith "error index must be positive"
                    else nth(tail,k-1)
;;
   
let rec add_nth(l,e,k) =
  if k < 0
  then failwith" error index must be in [0..len(l)]"
  else
  (
      match (l,k) with
        (_,0) -> e::l
      | ([],_) -> failwith "error index must be in [0..len(l)]"
      | (hd::tail,k) -> hd::add_nth(tail,e,k-1)
  )
;;
let add_fst(l,e) = add_nth(l,e,0) ;;
let add_lst(l,e) = add_nth(l,e,len(l)) ;;

let rec rem_nth(l,k) =
  if k < 0
  then failwith" error index must be in [0..len(l)]"
  else
  begin
    match (l,k) with
        ([],_) -> failwith "error index must be in [0..len(l)-1]"
      | (hd::tail,0) -> tail
      | (hd::tail,k) -> hd::rem_nth(tail,k-1)
  end
;;
let rem_fst(l) = rem_nth(l,0) ;;
let rem_lst(l) = rem_nth(l,len(l)-1) ;;


let append(l : 'a list, m : 'a list) : 'a list =
    l@m
;;

let rec flat(l : 'a list list) : 'a list =
    match l with
      [] -> []
    |  a::sl -> a @ flat(sl)
;;


(* Fonctions de manipulation de tableaux *)

let arr_len(t) = Array.length t ;;

let arr_make(n, v) = Array.create n v ;;

(* Fonctions de manipulation d'entiers aléatoires *)

let random_object = new System.Random();;

let random_int(a : int, b : int) : int = random_object.Next(a,b) ;;

let random_int_unary(a) : int = random_object.Next(a);;

let random_bool() : bool = random_object.NextDouble() < 0.5;;

let print_string(s : string) : unit =
    printf "%s" s
;;

let print_newline() : unit =
    printfn ""
;;

let print_endline(s :string) : unit =
    printfn "%s" s
;;

let print_int(i : int) : unit =
    printf "%i" i
;;

let print_float(f : float) : unit =
    printf "%f" f
;;

let read_line() : string =
    Console.ReadLine()
;;

let rec read_token_aux(acc : string) : string =
    let p = Console.Read() in
    let c = Char.ConvertFromUtf32(p) in
    if Char.IsWhiteSpace(c.[0]) then 
        acc
    else
        read_token_aux(acc + c)
;;

let read_int() : int =
    let line = read_line() in
        match (System.Int32.TryParse(line)) with
            | (true, value) -> value
            | (false, _) -> failwith ("Invalid int in <"+line+">")
;;

let read_float() : float =
    let line = read_line() in
        match (System.Double.TryParse(line)) with
            | (true, value) -> value
            | (false, _) -> failwith ("Invalid float in <"+line+">")
;;

let read_char() : char =
    let line = read_line() in
        match (System.Char.TryParse(line)) with
            | (true, value) -> value
            | (false, _) -> failwith ("Invalid char in <"+line+">")
;;

let int_of_float(x : float) : int =
    int(x)
;;

let float_of_int(x : int) : float =
    float(x)
;;

let float_of_string(x:string) : float =
    float(x)
;;

let int_of_string(x:string) : int =
    int(x)
;;

let string_of_float(x:float) : string =
    string(x)
;;

let string_of_int(x:int) : string =
    string(x)
;;

let string_of_bool(x:bool) : string =
    if x
    then "true"
    else "false"
;;

let bool_of_string(x:string) : bool =
    "true".Equals(x.ToLower())
;;

let min(a,b) =
    min a b
;;

let max(a,b) =
    max a b
;;

