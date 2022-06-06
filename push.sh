#!/bin/bash
mkdir ignore
filename='ficheroMover.txt'
while read line; do
mv TFGunity/$line ignore
done < $filename
tar -zcvf ignore.tar.gz ignore
rm -r ignore