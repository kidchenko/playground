card = 88;

bingo = fn 
  (88) -> "Bingo!"
  (_) -> "No win"
end

IO.puts bingo.(card)