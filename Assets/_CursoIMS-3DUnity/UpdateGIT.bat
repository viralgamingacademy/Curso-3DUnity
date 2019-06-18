git config --global user.email "alumno@viralstudios.es"
git add -A
git commit -m alumno
git fetch origin master
git merge -s recursive -X theirs origin/master