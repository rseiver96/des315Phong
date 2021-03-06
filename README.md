# Phong - A Pong remake with more JUICE

Here is the website for this repository: https://amoghsubhedar.github.io/des315Phong
<br>A playable version of the game is hosted on that.

## About
This repository contains a unity project which I made for a class where the objective of the assignment was to take a classic arcade game and add some game feel elements to it.
I uploaded this project to github so that I could use workflows to create a CI pipeline. Every change committed to the main branch will fire a container that builds a WebGL build of the unity project, commits the build to another branch and hosts it using github pages.

## Branches
- main  : Contains all the files and assets required to build a unity project
- builds: WebGL build of the most recent unity project built from main. This branch acts as the backend for the repo's github pages.
- backup/release: Older branches that were used to test unity builder.

## References
I used these actions from the github marketplace to build the pipeline
- [Unity Builder](https://github.com/marketplace/actions/unity-builder)
- [Git Auto Commit](https://github.com/marketplace/actions/git-auto-commit)
