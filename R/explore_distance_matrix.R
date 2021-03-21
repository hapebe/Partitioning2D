datafilepath <- "D:/home/hapebe/self-made/coding/Partitioning2D/Data/"

# subject <- "11-square ODD"
subject <- "HP-Test3 ODD"
# subject <- "HP-Test3 EUC"

# df <- read.csv(paste0(datafilepath, "11-square-oddDistances.txt"), header=TRUE, sep="\t", na="")
df <- read.csv(paste0(datafilepath, "HP-Test3-oddDistances.xl.txt"), header=TRUE, sep="\t", na="")
# df <- read.csv(paste0(datafilepath, "HP-Test3-eucDistances.xl.txt"), header=TRUE, sep="\t", na="")
str(df) ; df$distance

hist(df$distance, breaks = 400, main = "Histogram of Inter-Point Distance", xlab = subject, col = "lightblue")
hist(df$distance, main = "Histogram of Inter-Point Distance", xlab = subject, col = "lightblue")
median1 <- median(df$distance) ; median1
mean1 <- mean(df$distance) ; mean1
sd1 <- sd(df$distance) ; sd1

# add a histogram curve, see https://stackoverflow.com/questions/35403643/multiple-histogram-with-overlay-standard-deviation-curve-in-r
curve(dnorm(x, mean=mean1, sd=sd1) * 268270, col="darkblue", lwd=2, add=TRUE, yaxt="n")
abline(v = median1, col="red")
abline(v = mean1)
abline(v = mean1+sd1, lty = 2)
abline(v = mean1-sd1, lty = 2)


freqs <- as.data.frame(table(df$distance))
colnames(freqs) <- c("Point-to-Point ODD", "Frequency")
freqs

# write.table(freqs, paste0(datafilepath, "11-square-oddDistances-freqs.txt"), sep="\t") 
