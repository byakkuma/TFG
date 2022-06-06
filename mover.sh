#!/bin/bash
filename='ficheroMover.txt'
while read line; do
#echo "Linea: ~/TFG/$line"
mv ~/TFG/TFGunity/$line ~/
done < $filename