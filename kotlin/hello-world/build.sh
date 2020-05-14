#!/bin/bash
echo "Removing old 'dist' folder..."

rm -rf ./dist
mkdir ./dist

echo "Building 'src/hello-world.kt'"
echo "..."

kotlinc src/hello-world.kt -include-runtime -d ./dist/program.jar

echo "Finished..."
echo "Created program.jar"
echo "..."
echo "You can now run it with: 'java -jar dist/program.jar'"

