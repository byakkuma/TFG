#!/bin/bash
filename='ficheroMover.txt'
while read line; do
mv TFGunity/$line ./ignore
done < $filename
#zip -r ignore.zip ignore