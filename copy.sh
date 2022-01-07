ls -1 ./src/library | sed -e 's/.cs//g' > library.txt

grep -oE "[A-Z][a-zA-Z]+" $1 | awk '/Library/, /--/' | sort | uniq | cat - library.txt | sort | uniq -d | awk '{print "src/library/"$1".cs"}' | xargs cat | awk '$1 !~ "using"{print}' | cat $1 - | pbcopy