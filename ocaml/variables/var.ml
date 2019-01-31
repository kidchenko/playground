let x = 3;;
(*
* print_string x;; this will break because x is a int and print_string expect a string
*)
print_int x;;
let y = 4;;
print_int y;;
y = 1;;
let z = x + y;;
z = 2;;
print_int z;;
