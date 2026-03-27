#!/bin/bash

# Settings for Sensor Test Data service
APP_NAME="SensorTestData"
ZIP_FILE="SensorTestData.zip"
INSTALL_DIR="/opt/burstroy/testdata"
USER_NAME="burstroy"

# Root check
if [ "$EUID" -ne 0 ]; then 
    echo "Please run as root: sudo $0"
    exit 1
fi

# Check if zip exists
if [ ! -f "$ZIP_FILE" ]; then
    echo "Error: $ZIP_FILE not found in current directory."
    echo "Please ensure $ZIP_FILE is in the current directory."
    exit 1
fi

echo "Installing $APP_NAME to $INSTALL_DIR..."

# Create directory if not exists
mkdir -p "$INSTALL_DIR"

# Stop service before update if it exists
if systemctl is-active --quiet burstroy-sensor-test-data; then
    echo "Stopping burstroy-sensor-test-data service..."
    systemctl stop burstroy-sensor-test-data
fi

# Recreate directory to ensure it's empty and exists
echo "Cleaning and recreating $INSTALL_DIR..."
rm -rf "$INSTALL_DIR"
mkdir -p "$INSTALL_DIR"

# Unzip
echo "Unpacking $ZIP_FILE..."
unzip -o "$ZIP_FILE" -d "$INSTALL_DIR"

# Make executable
echo "Setting permissions..."
chmod +x "$INSTALL_DIR/$APP_NAME"
chown -R "$USER_NAME:$USER_NAME" "$INSTALL_DIR"

# Check file type
echo "File info for $APP_NAME:"
file "$INSTALL_DIR/$APP_NAME"

# Check if it's a valid executable
if [ -x "$INSTALL_DIR/$APP_NAME" ]; then
    echo "✅ $APP_NAME installed successfully."
else
    echo "⚠️  Warning: $APP_NAME is not executable or has incorrect format."
fi

echo ""
echo "Installation complete. You can now:"
echo "  1. Create service: sudo ./create-service-sensor-test-data.sh"
echo "  2. Or start manually: $INSTALL_DIR/$APP_NAME"