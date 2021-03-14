n <- 1000000

x0 <- rnorm(n) # ; x0
x1 <- rnorm(n) # ; x1
dx <- abs(x1-x0)
# hist(dx, breaks = 500,xlim = c(0,2))

y0 <- rnorm(n) # ; y0
y1 <- rnorm(n) # ; y1
dy <- abs(y1-y0)

z0 <- rnorm(n) # ; z0
z1 <- rnorm(n) # ; z1
dz <- abs(z1-z0)

maxdelta <- pmax(dx, dy)
maxdelta2 <- pmax(dx, dy) ; maxdelta3 <- pmax(dx, dy, dz) ; hist(maxdelta3-maxdelta2, breaks = 200)
mean(maxdelta) ; sd(maxdelta)
hist(maxdelta, breaks = 200, xlim = c(0,6))
euclidean <- sqrt(dx*dx+dy*dy)
# mean(euclidean) ; sd(euclidean)
# hist(euclidean, breaks = 200, xlim = c(0,6))



library(RColorBrewer)
library(hexbin)
rf <- colorRampPalette(rev(brewer.pal(11,'Spectral')))
r <- rf(64)
df2 <- data.frame(dx, dy)
colnames(df2) <- c("dx", "dy")
h <- hexbin(df2, xbins = 100)
plot(h, colramp=rf)


df3 <- data.frame(sqrt(x0*x0+y0*y0), maxdelta)
colnames(df3) <- c("vector_length", "maxdelta")
h <- hexbin(df3, xbins = 200)
plot(h, colramp=rf)


# Kernel density estimation, see https://www.r-bloggers.com/2014/09/5-ways-to-do-2d-histograms-in-r/
library(MASS)
# Default call 
k <- kde2d(df3$vector_length, df3$maxdelta)
image(k, col=r)
# Adjust binning (interpolate - can be computationally intensive for large datasets)
k <- kde2d(df3$vector_length, df3$maxdelta, n=200)
image(k, col=r)



df <- data.frame(dx, dy, maxdelta)
colnames(df) <- c("dx", "dy", "maxdelta")
# print(df)

summary(df$dx)
mean(df$dx) ; sd(df$dx)

hist(df$maxdelta, breaks = 200, xlim = c(0,6))
mean(df$maxdelta)
sd(df$maxdelta)
