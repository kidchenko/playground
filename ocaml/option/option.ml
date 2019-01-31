let maybe_fail (size) =
  if size > 10 then 
    None
  else 
    Some size

let value_or_default n = 
  match maybe_fail n with
  | Some x -> x
  | None -> 0

let a = value_or_default 1;;
print_int a;;
print_string "\n"

let b = value_or_default 11;;
print_int b;;
