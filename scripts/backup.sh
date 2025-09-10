#!/bin/bash

#
# \file backup.sh
# \brief Script to create a database dump
#
# This script create a database dump in the /backup directory
#
# \date 10-09-2025
#

TIMESTAMP=$(date +%Y-%m-%d_%H-%M-%S)
BACKUP_DIR="../backup"
FILENAME="$BACKUP_DIR/db_$TIMESTAMP.sql"

echo "Creating backup..."

mkdir -p "$BACKUP_DIR"

docker exec -t postgres pg_dump -U $DB_USERNAME -d $DB_DATABASE > $FILENAME

echo "Backup saved to backup/$FILENAME"
