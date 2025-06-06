# Changelog

## [Unreleased]

### Added

- Add support for StyleCop & .NET Analyzers
- Use RIN via gRPC for the player management
- Add many items to the game
  - Deployables
  - Battlestation
  - Vehicles
  - Gliders
  - Abilities
  - Thumbers
  - Turrets
  - Melding Repulsor
- Add Bepu as physics engine

### Changed

- Update build pipeline to support .NET 8 & 9 and the latest macOS version
- Update most dependencies

### Fixed

- Make the server handling code more robust
- Many improvements in the entity definitions

## [1.2.0] - 2023-06-02

### Added

- Add support for calling down a LGV
- Add documentation to explain the architecture
- Use Autofac for dependency injection in UdpHosts
- Add basic endpoint for character creation handling
- Add or extend the API endpoints
  - api/v2/accounts/current/status
  - api/v2/accounts/character_slots
  - api/v3/characters/{character_id}/garage_slots
  - api/v3/ui_actions
  - api/v1/characters/{character_id}/data
  - api/v3/characters/{character_id}/inventories/bag
  - api/v3/characters/{character_id}/inventories/gear/items
  - api/v1/zones/queue_ids
  - api/v2/zone_settings
  - api/v1/item_display_attributes
  - api/v1/market_categories
  - api/v1/characters/validate_name
  - api/v3/characters/{characterId}/titles
  - api/v3/characters/{characterId}/garage_slots/{frameId}/perks
  - ...and more
- Use AeroMessages as submodule instead of a binary reference
- Use range indexer
- Modernize code base with support from Rider auto format and clean up
- Handling of the Steam user id. Currently, it is only held internally and not persisted.
- Basic GitHub Action to ensure continuous integration
- Individual .bat files for each game service pointing directly to the respective `bin\debug` folder.
- Configuration for the game server. You can edit the `App.config` file in the `GameServer` project root for local settings and add working defaults in `App.Default.config`.
  `App.config` will be generated from `App.Default.config` if not present before build.
  Currently, the only option present is the Serilog log level.
- CLI options parsing. Currently, the only option is the log level. Specifying wrong options will not stop the server from starting.
- 404 handling to the web server pipeline which prints the contents of 404-producing requests as warnings to see what's missing.
- ClientEventController with a corresponding endpoint to receive the events from the client. Currently, only the client uptime seems to be posted on exit of the game

### Changed

- Jets rendering correctly
- Use AeroMessages for nearly all packets
- Clean up some of the code flow, for easier understanding
- Use long speaking names for variables
- Started transition to AeroMessages, this is an incremental process
- Replace SharedAssemblyInfo with a targets file
- Update to .NET 6
- Changed 'missing MSGid' logging to include the details (1st message) in log level warning instead of verbose
- Update documentation regarding the usage of web hosts
- Turn Firefall specific location finder to a common location provider

### Fixed

- Fix IndexOutOfRangeException being thrown by the Matrix server
- Fix string deserialization and corrected Matrix Login packet

## [1.1.0] - 2021-10-09

### Added

- Characters for each available zone with usable spawn location

## [1.0.0] - 2021-10-06

### Added

- MatrixServer to handle client connection establishment and hand off to GameServer
  - Supports all five packets: ABRT, HEHE, HUGG, KISS, POKE
- GameServer to handle map zoning and basic character movement
  - Zone into New Eden
  - Spawn on a Watch Tower
  - Have a pre-defined set of Visuals
  - Use your Primary and Secondary Weapon (sometimes it doesn't work)
  - Run and sprint around the whole map
- WebHostManager to deal with standard web requests from the client through different WebHosts
  - Handle login requests via hardcoded Oracle ticket
  - Provide hardcoded account details
  - Serve the necessary Host Information
  - Return static assets when provided by the user
