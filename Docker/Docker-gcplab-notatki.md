- run a hello world container to get started:
```docker run hello-world```

Run the following command to take a look at the container image it pulled from Docker Hub:
```docker images```

	- Command output
		> REPOSITORY     TAG      IMAGE ID       CREATED       SIZE
		> hello-world    latest   1815c82652c0   6 days ago    1.84 kB

- look at the running containers by running the following command
```docker ps```

	- Command Output
		> CONTAINER ID        IMAGE               COMMAND             CREATED             STATUS              PORTS               NAMES


- There are no running containers. The hello-world containers you ran previously already exited. In order to see all containers, including ones that have finished executing, run ```docker ps -a```

	- Command Output
		> CONTAINER ID   IMAGE         COMMAND    CREATED         STATUS                     PORTS     NAMES
		> 1c293ed54de3   hello-world   "/hello"   9 minutes ago   Exited (0) 9 minutes ago             objective_austin
		> e1163641170c   hello-world   "/hello"   9 minutes ago   Exited (0) 9 minutes ago             sweet_galileo


