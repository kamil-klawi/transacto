#!/bin/bash

#
# \file undeploy.sh
# \brief Script to stop and remove Docker Compose services
#
# This script stop and remove Docker Compose services:
# - Removes volumes
# - Removes networks
# - Stops containers
#
# \date 13-09-2025
#

if [ ! -f ".env" ]; then
  echo "Error: .env file not found!"
  exit 1
fi

echo "Stopping and removing Docker Compose services..."

docker compose --env-file .env down -v
