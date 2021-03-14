# https://uc-r.github.io/kmeans_clustering

# install.packages("tidyverse")
library(tidyverse)  # data manipulation
library(cluster)    # clustering algorithms
# install.packages("factoextra")
library(factoextra) # clustering algorithms & visualization

df <- read.csv(file="D:/home/hapebe/self-made/coding/clustering/HP-Test6-p4548,0-coords.txt", header=TRUE, sep="\t", na="")
df <- read.csv(file="D:/home/hapebe/self-made/coding/clustering/HP-Test3-p4742,0-coords.txt", header=TRUE, sep="\t", na="")
df <- read.csv(file="D:/home/hapebe/self-made/coding/clustering/landscape_auslegeoptionen3-p4701,0-coords.txt", header=TRUE, sep="\t", na="")
# str(df)
# head(df)

idsdf <- df[c("no", "ID")]
subdf <- df[c("x", "y")]



distance <- get_dist(subdf)
fviz_dist(distance, gradient = list(low = "#00AFBB", mid = "white", high = "#FC4E07"))

k2 <- kmeans(subdf, centers = 12, nstart = 100)
str(k2)

fviz_cluster(k2, data = subdf)
