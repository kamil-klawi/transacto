#
# \file Dockerfile
# \brief Dockerfile to create an image for building and running the frontend application
#
# Exposes ports 3000 and 3001 for the frontend service
#
# \date 10-09-2025
# \updated 13-09-2025
#

ARG NODE_VERSION=22.19-alpine

#
# BUILD
#
FROM node:$NODE_VERSION AS builder

RUN corepack enable && corepack prepare pnpm@10.12.4 --activate

WORKDIR /app

COPY apps/frontend/package.json apps/frontend/pnpm-lock.yaml ./

RUN pnpm install --frozen-lockfile

COPY apps/frontend .

RUN pnpm build

#
# PRODUCTION
#
FROM node:$NODE_VERSION AS production

RUN addgroup -S app && adduser -S -G app app

WORKDIR /app

COPY --from=builder /app/package.json ./
COPY --from=builder /app/pnpm-lock.yaml ./
COPY --from=builder /app/node_modules ./node_modules
COPY --from=builder /app/.next ./.next
COPY --from=builder /app/public ./public

RUN chown -R app:app /app

USER app

EXPOSE 3000
EXPOSE 3001

CMD ["pnpm", "start"]
