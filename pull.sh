#!/bin/bash

# actualizamos el poryecto
git pull

# descomprimimos
tar xfv ignore.tar.gz
filename='ficheroMover.txt'
while read line; do
mv ignore/$line TFGunity
done < $filename
rm -r ignore
rm -r ignore.tar.gz
