# My first line
## How to deploy to Heroku
-build container (where the dockerfile is):
```
docker build -t imageName(ex:'radu_hww') .
```
-create docker container and run it
```
docker run -d -p 8081:80 --name radu_hww_container radu_hww
```
-login to Heroku:
```
heroku login
heroku container:login
```
-build the Dockerfile in the current directory and push the container
```
heroku container:push -a radu-hww web
```

-release the container.
```
heroku container:release -a radu-hww web
```