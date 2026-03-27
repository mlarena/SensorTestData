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

# Check if installation exists
if [ ! -d "$INSTALL_DIR" ]; then
    echo "Error: Installation directory $INSTALL_DIR does not exist."
    echo "Please run install script first: sudo ./install-sensor-test-data.sh"
    exit 1
fi

echo "Updating $APP_NAME in $INSTALL_DIR (preserving configuration)..."

# Stop service before update
if systemctl is-active --quiet burstroy-sensor-test-data; then
    echo "Stopping burstroy-sensor-test-data service..."
    systemctl stop burstroy-sensor-test-data
fi

# Create a temporary directory for extraction
TMP_EXTRACT="/tmp/burstroy_testdata_update"
rm -rf "$TMP_EXTRACT"
mkdir -p "$TMP_EXTRACT"

# Unzip to temp
echo "Extracting $ZIP_FILE to temporary folder..."
unzip -o "$ZIP_FILE" -d "$TMP_EXTRACT"

# Update executable
echo "Updating executable..."
cp "$TMP_EXTRACT/$APP_NAME" "$INSTALL_DIR/"

# Copy any other necessary files (but preserve configs)
# Uncomment if you need to copy additional files:
# cp "$TMP_EXTRACT/"*.dll "$INSTALL_DIR/" 2>/dev/null || true
# cp "$TMP_EXTRACT/"*.json "$INSTALL_DIR/" 2>/dev/null || true

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
echo ""
echo "You can now start the service: sudo systemctl start burstroy-sensor-test-data"
echo "Check status: sudo systemctl status burstroy-sensor-test-data"