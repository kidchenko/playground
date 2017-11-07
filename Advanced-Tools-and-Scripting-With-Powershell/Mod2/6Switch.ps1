# Switch can be easier to maintain than If statement
#and can provide additional features

$status = 3
Switch ($status) {
  0 { $status_text = 'ok' }
  1 { $status_text = 'error' }
  2 { $status_text = 'jammed' }
  3 { $status_text = 'overheated' }
  4 { $status_text = 'empty' }
  default { $status_text = 'unknown' }
}
$status_text

# Better
$status = 0
$status_text = switch ($status) {
  0 { 'ok' }
  1 { 'error' }
  2 { 'jammed' }
  3 { 'overheated' }
  4 { 'empty' }
  default { 'unknown' }
}
$status_text