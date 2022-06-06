#!/bin/bash

# excluimos los ficheros que git no puede manejar
mkdir ignore
filename='ficheroMover.txt'
while read line; do
mv TFGunity/$line ignore
done < $filename
tar -zcvf ignore.tar.gz ignore
rm -r ignore

# guardamos los ficheros con git
git add .
echo "Commit: "
read commit
git commit -m "$commit"
git push