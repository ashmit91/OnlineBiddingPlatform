# ---------- Step 1: Build the React app ----------
FROM node:18-alpine AS build

WORKDIR /app

# Install dependencies
COPY package*.json ./
RUN npm install

# Copy all files and build
COPY . .
RUN npm run build

# ---------- Step 2: Serve the app ----------
FROM nginx:alpine

# Copy the build folder to NGINX public folder
COPY --from=build /app/build /usr/share/nginx/html

# Remove default nginx config and copy your custom config (optional)
# COPY nginx.conf /etc/nginx/nginx.conf

EXPOSE 80

# Start nginx
CMD ["nginx", "-g", "daemon off;"]
