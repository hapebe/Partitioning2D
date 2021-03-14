# install.packages("e1071")
library(e1071)
# install.packages("ggplot2")
library(ggplot2)

# df <- read.csv(file="D:/home/hapebe/self-made/coding/clustering/HP-Test6-p4548,0-coords.txt", header=TRUE, sep="\t", na="")
df <- read.csv(file="D:/home/hapebe/self-made/coding/clustering/HP-Test3-p4742,0-coords.txt", header=TRUE, sep="\t", na="")
# df <- read.csv(file="D:/home/hapebe/self-made/coding/clustering/landscape_auslegeoptionen3-p4701,0-coords.txt", header=TRUE, sep="\t", na="")
# str(df)

idsdf <- df[c("no", "ID")]
subdf <- df[c("x", "y")]
# str(subdf)

# prepare data?
# subdf <- na.omit(subdf) # listwise deletion of missing
# subdf <- scale(subdf) # standardize variables

# Determine number of clusters
wss <- (nrow(subdf)-1)*sum(apply(subdf,2,var))
for (i in 2:15) wss[i] <- sum(kmeans(subdf, centers=i)$withinss) * i
plot(1:15, wss, type="b", xlab="Number of Clusters", ylab="Within groups sum of squares")

# K-Means Cluster Analysis
fit <- kmeans(subdf, 12, nstart = 100)
fit
fit$iter
# get cluster means
aggregate(subdf,by=list(fit$cluster),FUN=mean)
# append cluster assignment
df <- data.frame(idsdf, subdf, fit$cluster) 
names(df)[names(df) == "fit.cluster"] <- "cluster"
df[,'cluster']<-factor(df[,'cluster'])

# , shape = Predicted
qplot(x, y, colour = cluster, data = df)




# Model Based Clustering
# install.packages("mclust")
library(mclust)

ICL <- mclustICL(subdf)
summary(ICL)
plot(ICL)

mclust.options("emModelNames")
BIC <- mclustBIC(subdf)
fit <- Mclust(subdf, x=BIC, G=2:4, modelNames=c("VVV"))
summary(fit, parameters = TRUE) # display the best model
plot(fit, what="classification") # plot results


# hierarchical clustering
d <- dist(subdf, method = "euclidean") # Euclidean distance matrix.
hfit <- hclust(d, method="ward.D")
plot(hfit) # display dendogram
# draw dendogram with red borders around the 5 clusters
rect.hclust(hfit, k=4, border="red") 
cluster <- cutree(hfit, k=4) # cut tree into ... clusters
df <- data.frame(idsdf, subdf, cluster) 
df[,'cluster']<-factor(df[,'cluster'])
qplot(x, y, colour = cluster, data = df)
