#!/bin/bash
current_state=`/usr/sbin/lsof -i 4UDP | grep zoom.us | wc -l`
if [[ "$current_state" -eq "0" ]]; then
    printf "false"
else
    printf "true"
fi
