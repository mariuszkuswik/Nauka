# Introduction to Git

This documents contains some of the basic commands that you will need to get started with Git and GitHub

# Contents
1. [Basic Commands 1](#basic-commands-1)
2. [Basic Commands 2](#basic-commands-2)
3. [Basic Commands 3](#basic-commands-3)
4. [Activity 1](#activity-1)
5. [Activity 2](#activity-2)
6. [Activity 3](#activity-3)
7. [Activity 4](#activity-4)
8. [Danger Commands](#danger-commands)
8. [Next Steps](#next-steps)

# Basic Commands 1

1. Initialize a repository *Run this **ONLY ONCE***: 
```git init```

2. Check the status of the repository: 
```git status```

3. Add file(s) to the staging area
    * For individual files: ```git add <filename>``` 
    * For all files: ```git add .```

4. Commit changes (Take a screenshot of code): 
```git commit -m "Initial Commit"```

5. List out all the commits: 
```git log```

6. Check the difference between file changes: 
```git diff```

7. List out all the branches: 
```git branch```

8. Create a new branch: 
```git branch <branch_name>```

9. Merge other branches with master branch: 
```git merge master <branch_to_be_merged>```

# Activity 1

1. Create a new branch
2. Add two commits in that branch
3. Merge with master

# Basic Commands 2

1. List out all the remotes: ```git remote```
2. Add remote to current repository: 
```git remote add <remote name> <github link>```
3. Long list remotes:
```git remote -v```
4. Push local to changes to master branch of origin remote: ```git push -u origin master```

# Activity 2

1. Make a lot of changes in the master branch
2. Add, commit, push 
3. See the output on github

# Activity 3

Create a file called .gitignore in the root

1. Use any existing node/react app
2. Init, add, commit
3. Ignore relevant files (Eg: Node modules)
4. Push to github

# Activity 4

1. Find out the difference between (locally)
    * clone from dctacademy
    * clone from your account
2. Use these tools to understand
    * branch
    * remote
    * commits
3. Create a new node/react app and push to github

# Activity 5
1. Create a new repo on github - sample-mern
2. Create a new node app - local machine
3. Create a new react app - local machine 
4. Inside the node app, create a new folder called
"client"
5. Copy contents of the new react app into the client folder

or

- Run create-react-app in node app and call it 'client'
6. Go inside the client folder and remove .git file
(Command to remove .git: rm -rf .git)
(For Windows: rmdir /a .git)
7. Ignore relevant files in - node app - .gitignore should
be at the root of node app

# Basic Commands 3

1. Add an upstream remote: ```git remote add upstream ```<admin-repo-link> 

2. Pull changes from the admin repo to your local repo: 
```git pull upstream master```

# Danger Commands

1. Undo latest commit (Only local): 
```git revert HEAD```

2. Destroy all exisiting changes: 
```git checkout .```

3. **Stash:** Keep temprary copy of current changes without a commit
    * Stash current changes: ```git stash```
    * Pop lastest stash: ```git stash pop```
    * List all stashes: ```git stash show```
    * List stash with changes:```git stash show -p```
    
## GitHub CLI

```gh``` is GitHub on the command line, and it’s now available in beta. It brings pull requests, issues, and other GitHub concepts to the terminal next to where you are already working with git and your code.

## Usage

### Commands
To view detail on any command, use gh [command] [subcommand] --help

- ```gh issue [status, list, view, create]```
- ```gh pr [status, list, view, checkout, create]```
- ```gh repo [clone, create, fork, view]```
- ```gh config [get, set]```
- ```gh help```

### Global flags

```
      --help              Show help for command
  -R, --repo OWNER/REPO   Select another repository using the OWNER/REPO format
      --version           Show gh version
```

# Next Steps 

* Check out: [Advanced GitHub](https://github.com/dctacademy/advanced-github)

# Advanced GitHub Overview

![alt text](github.jpg)
