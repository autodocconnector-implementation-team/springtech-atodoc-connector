echo "BUILD autodoc-connector-backend"
docker build . -f Dockerfile.dev --force-rm -t atodoc-connector-backend:dev
