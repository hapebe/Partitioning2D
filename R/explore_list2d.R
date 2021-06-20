datafilepath <- "D:/home/hapebe/self-made/coding/Partitioning2D/Data/"

subject <- "Gaussian-1000000"

df <- read.csv(paste0(datafilepath, subject, ".txt"), header=TRUE, sep="\t", na="")
str(df) 

subdf <- df[c("x", "y")]
# plot(subdf)

summary(df)
sd(df$x)
sd(df$y)

# load extra libs:
# density plots:
library(hexbin)
library(RColorBrewer)

# density plot:
h <- hexbin(subdf, xbins = 96)
rf <- colorRampPalette(rev(brewer.pal(11,'Spectral'))) # ; r <- rf(32)
plot(h, colramp=rf, main="Heatmap: x X y", xlab="x", ylab="y", trans=log, inv=exp)

# histogram with normal distribution overlay:
value <- df$x

m<-mean(value)
s<-sqrt(var(value))
hist(value, prob=TRUE, xlab="variable", ylim=c(0, 1))
curve(dnorm(x, mean=m, sd=s), col="darkblue", lwd=2, add=TRUE, yaxt="n")
