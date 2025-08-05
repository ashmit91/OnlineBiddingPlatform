# ----------- Step 1: Build Stage -----------
FROM maven:3.9.6-eclipse-temurin-17 AS build

# Set working directory inside the container
WORKDIR /app

# Copy pom.xml and download dependencies first (for cache)
COPY pom.xml .

# Download dependencies
RUN mvn dependency:go-offline

# Copy source code and build the jar
COPY src ./src

# Build the Spring Boot application
RUN mvn clean package -DskipTests

# ----------- Step 2: Run Stage -----------
FROM openjdk:17-jdk-slim

# Set working directory
WORKDIR /app

# Copy the jar file from the build stage
COPY --from=build /app/target/*.jar app.jar

# Expose port
EXPOSE 8080

# Run the jar
ENTRYPOINT ["java", "-jar", "app.jar"]
