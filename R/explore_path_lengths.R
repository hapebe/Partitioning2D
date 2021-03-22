datafilepath <- "D:/home/hapebe/self-made/coding/Partitioning2D/Data/"

# subject <- "HP-Test3"
# subject <- "2-square"
# subject <- "3-square"
# subject <- "4-square"
# subject <- "5-square"
# subject <- "6-square"
# subject <- "7-square"
# subject <- "8-square"
# subject <- "9-square"
# subject <- "10-square"
# subject <- "11-square"
# subject <- "12-square"
# subject <- "13-square"
# subject <- "14-square"
# subject <- "15-square"
# subject <- "16-square"
# subject <- "17-square"
# subject <- "18-square"
subject <- "30-square"

source <- paste0(subject, "-pathLengths.xl.txt")

df <- read.csv(file=paste0(datafilepath, source), header=TRUE, sep="\t", na="")
# str(df) ; df$path_length
median1 <- median(df$path_length) ; median1
mean1 <- mean(df$path_length) ; mean1
sd1 <- sd(df$path_length) ; sd1
table(df$path_length)

# freq=FALSE makes sure the normal curve does not need "upscaling"
hist(df$path_length, breaks = 200, main = "Histogram of Path Length", xlab = paste0(subject, " (Euclidean)"), col="lightblue", freq=FALSE)

# add a histogram curve, see https://stackoverflow.com/questions/35403643/multiple-histogram-with-overlay-standard-deviation-curve-in-r
curve(dnorm(x, mean=mean1, sd=sd1), col="darkblue", lwd=2, add=TRUE, yaxt="n")
abline(v = median1, col="red")
abline(v = mean1)
abline(v = mean1+sd1, lty = 2)
abline(v = mean1-sd1, lty = 2)
abline(v = mean1+2*sd1, lty = 2)
abline(v = mean1-2*sd1, lty = 2)
