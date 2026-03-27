#!/bin/bash

# Settings for Worker service
APP_NAME="BurstroyMonitoring.Worker"
ZIP_FILE="BurstroyMonitoring.Worker.zip"
INSTALL_DIR="/opt/burstroy/worker"
USER_NAME="burstroy"

# Root check
if [ "$EUID" -ne 0 ]; then 
    echo "Please run as root: sudo $0"
    exit 1
fi

# Check if zip exists
if [ ! -f "$ZIP_FILE" ]; then
    echo "Error: $ZIP_FILE not found in current directory."
    exit 1
fi

echo "Updating $APP_NAME in $INSTALL_DIR (preserving config)..."

# Stop service before update
if systemctl is-active --quiet burstroy-worker; then
    echo "Stopping burstroy-worker service..."
    systemctl stop burstroy-worker
fi

# Create a temporary directory for extraction
TMP_EXTRACT="/tmp/burstroy_worker_update"
rm -rf "$TMP_EXTRACT"
mkdir -p "$TMP_EXTRACT"

# Unzip to temp
echo "Extracting $ZIP_FILE to temporary folder..."
unzip -o "$ZIP_FILE" -d "$TMP_EXTRACT"

# Update executable
echo "Updating executable..."
cp "$TMP_EXTRACT/$APP_NAME" "$INSTALL_DIR/"

# Make executable
echo "Setting permissions..."
chmod +x "$INSTALL_DIR/$APP_NAME"
chown -R "$USER_NAME:$USER_NAME" "$INSTALL_DIR"

# Check file type
echo "File info for $APP_NAME:"
file "$INSTALL_DIR/$APP_NAME"

# Cleanup temp
rm -rf "$TMP_EXTRACT"

echo "✅ $APP_NAME updated successfully."
echo "You can now start the service: sudo systemctl start burstroy-worker"
