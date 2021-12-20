Feature: WebApi

    Scenario: Upload
    Given We have file to upload
    When We send a request to upload file
    Then File is uploaded to dropbox 

    Scenario: Delete
    Given We have file to delete
    When We send a request to delete file
    Then File is deleted on dropbox


    Scenario: Get_Metadata
    Given We want to get metadata of the file on dropbox
    When We send a request to get metadata
    Then We get metadata    

