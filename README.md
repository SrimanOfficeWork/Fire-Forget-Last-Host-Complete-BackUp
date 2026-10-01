# Async PDF Extraction Queue

## Overview

An asynchronous PDF extraction workflow designed to process Import and
Export documents through a queue-based architecture.

The process separates request submission, PDF processing, extraction
response handling, database tracking, and UI result monitoring so that
the application does not need to keep the original API connection open
until extraction is completed.

## Process Flow

``` text
Import / Export Application
        |
        | Process ID + PDF + Required Headers
        v
Extraction API
        |
        | Submit / Queue
        v
RabbitMQ
        |
        v
Processing Tracker
        |
        v
MSSQL
(Process ID / Job / Status / Request Data)
        |
        | PDF Processing
        v
AI PDF Extraction
        |
        | Extraction JSON Callback
        v
Callback API
        |
        v
MSSQL
(Update Status + Response JSON)
        |
        v
AI PDF Queue Extraction Screen
        |
        | Auto Refresh
        v
Import / Export Result
```

## Core Workflow

### 1. Request Submission

The Import/Export application submits the PDF and process information
using a unique `ProcessId`.

The request contains the required identification details such as:

-   Process ID
-   ERI ID
-   Client
-   Job Type
-   Import / Export
-   Server information
-   PDF/document details

The initial API connection does not remain open while the document is
being processed.

### 2. Queue Processing

The submitted process is placed into the processing queue.

The process information is stored in MSSQL with its current status so
that the application can track the document independently of the
original API connection.

Typical information includes:

``` text
ProcessId
ERIId
Server
Client
JobType
ProcessType
Status
RequestJson
ResponseJson
CreatedDate
CompletedDate
```

### 3. PDF AI Processing

The queued document is processed by the PDF extraction service.

The extraction service processes the document independently and
generates the required JSON output.

### 4. Callback Response

After extraction is completed, the generated JSON is posted to the
callback API.

The callback API identifies the corresponding process using the
`ProcessId` and updates the stored process record.

The response includes:

-   Process ID
-   Extraction status
-   Extraction JSON
-   Processing information
-   Completion details

### 5. Status Tracking

The database record is updated according to the response received.

Example statuses:

``` text
Queued
Processing
Completed
Failed
```

The status tracking allows the application to determine the current
state of every document without depending on a continuously open
connection.

### 6. UI Auto Refresh

The AI PDF Queue Extraction screen periodically checks the processing
status.

When a process is completed, the extraction response is displayed
through the appropriate Import or Export workflow.

The same queue-processing concept is used for both:

-   Import PDF processing
-   Export PDF processing

## Architecture

### Technology Stack

-   .NET 8
-   C#
-   ASP.NET Core Web API
-   Microsoft SQL Server
-   RabbitMQ
-   REST APIs
-   JSON
-   PDF / Document AI Processing
-   Auto-refresh UI

### Legacy Integration

Some integration points may interact with the existing .NET Framework
4.0 application.

The legacy application acts as part of the existing business workflow
while the asynchronous processing components handle queue management,
status tracking, callback processing, and extraction response
management.

## Server and ERI Tracking

Each process must retain sufficient information to identify where the
request originated.

Server and ERI information is stored along with the `ProcessId` so that
a callback response can be associated with the correct source and
business process.

This prevents responses from being incorrectly associated with another
server, ERI, client, or job.

## Key Design Principles

-   Asynchronous processing
-   Queue-based execution
-   Process ID based tracking
-   Callback-based completion
-   Database-backed status management
-   Import and Export support
-   Automatic UI status refresh
-   Server and ERI identification
-   Separation of request and response processing
-   Compatibility with existing legacy workflows

## High-Level Sequence

``` text
Submit
   ↓
Create Process
   ↓
Queue
   ↓
Store Status
   ↓
Process PDF
   ↓
Generate JSON
   ↓
Callback API
   ↓
Update Process
   ↓
Auto Refresh
   ↓
Display Result
```

## Purpose

The objective is to provide a reliable asynchronous PDF extraction
workflow where long-running document processing does not depend on a
continuously open API connection.

The process can be tracked from submission through completion using the
`ProcessId`, database status, queue state, and extraction response.
