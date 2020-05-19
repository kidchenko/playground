PROJ=$1
kotlinc $PROJ/main.kt -include-runtime -d $PROJ/main.jar -verbose
