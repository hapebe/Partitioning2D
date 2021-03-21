datafilepath <- "D:/home/hapebe/self-made/coding/Partitioning2D/Data/"

# subject <- "11-square ODD"
subject <- "HP-Test3 ODD"

df <- read.csv(paste0(datafilepath, "11-square-oddDistances.txt"), header=TRUE, sep="\t", na="")
df <- read.csv(paste0(datafilepath, "HP-Test3-oddDistances.xl.txt"), header=TRUE, sep="\t", na="")
str(df) ; df$distance

hist(df$distance, breaks = 400, main = "Histogram of Inter-Point Distance", xlab = subject, col = "lightblue")
hist(df$distance, main = "Histogram of Inter-Point Distance", xlab = subject, col = "lightblue")
summary(df$distance) ; sd(df$distance)

freqs <- as.data.frame(table(df$distance))
colnames(freqs) <- c("Point-to-Point ODD", "Frequency")
freqs

# write.table(freqs, paste0(datafilepath, "11-square-oddDistances-freqs.txt"), sep="\t") 
