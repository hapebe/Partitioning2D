datafilepath <- "D:/home/hapebe/self-made/coding/Partitioning2D/Data/"

subject <- "HP-Test3"
# subject <- "11-square"

source <- paste0(subject, "-pathLengths.xl.txt")

df <- read.csv(file=paste0(datafilepath, source), header=TRUE, sep="\t", na="")
# str(df) ; df$path_length

hist(df$path_length, breaks = 200, main = "Histogram of Path Length", xlab = paste0(subject, " (Euclidean)"))
median(df$path_length)
mean(df$path_length); sd(df$path_length)
