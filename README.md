# Sample OIDC Setup

## Adding (development only) URL ACLs

    # execute these
    netsh http add urlacl url=http://sample-api.devl:60136/ user=Everyone
    netsh http add urlacl url=http://zwei.devl:54448/ user=Everyone
    netsh http add urlacl url=http://ein.devl:56668/ user=Everyone

## Adding hosts file entry

    # open your hosts file as an administrator
    # C:\Windows\System32\drivers\etc\hosts

    # add this line
    127.0.0.1 ein.devl zwei.devl identity.devl

