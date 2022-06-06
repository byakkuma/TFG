#!/bin/bash
filename='ficheroMover.txt'
while read line; do
#echo "Linea: ~/TFG/$line"
mv ~/TFG/TFGunity/$line ~/TFG/ignore
done < $filename
zip -r ignore.zip ignore