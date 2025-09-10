#!/bin/bash

#
# \file deploy.sh
# \brief Deployment script for starting docker compose services
#
# This script build and starts the docker compoes services
#
# \date 10-09-2025
#

echo "Starting deployment..."

if [ -f ".env" ]; then
    echo "Loading environment from .env"
else
    echo "Missing .env file"
    exit 1
fi

docker compose --env-file .env up -d

echo "Deployment complete"
