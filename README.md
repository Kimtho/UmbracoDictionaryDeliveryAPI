# Umbraco Dictionary Delivery API

This project provides an API for accessing dictionary items in an Umbraco CMS application. It allows clients to retrieve dictionary items by key, all items, or all items under a specific key, with support for localization based on the `Accept-Language` header.

## Features

- **Retrieve Dictionary Item by Key**: Fetch a specific dictionary item using its key.
- **Retrieve All Dictionary Items**: Get all dictionary items at the root level, including their descendants.
- **Retrieve All Items Under a Specific Key**: Fetch all dictionary items that are descendants of a specified key.
- **Localization Support**: Responses are localized based on the `Accept-Language` header.

### Usage

The API provides the following endpoints:

- `GET /dictionary/{key}`: Retrieve a dictionary item by its key.
- `GET /dictionary/Items/`: Retrieve all dictionary items.
- `GET /dictionary/Items/{key}`: Retrieve all items under a specific key.

Responses are localized based on the `Accept-Language` header. Ensure to pass the appropriate language code to receive localized content.

## Versioning

We use [SemVer](http://semver.org/) for versioning. For the versions available, see the [tags on this repository](link).

## Authors

- **Kim Thomsen** - 

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details
