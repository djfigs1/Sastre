from typing import Dict

import yaml

from builder.section import ResumeSection


# Represents the data contained within a Me file
class MeFile:
    def __init__(self, path: str) -> None:
        with open(path, "r", encoding="utf8") as f:
            self.doc = yaml.safe_load(f)

    def get_name(self) -> str:
        return self.doc["Me"]["Name"]

    def get_contact_info(self) -> Dict[str, str]:
        contact_info = {}
        for key, val in self.doc["Me"].items():
            if key != "Name":
                contact_info[key] = val

        return contact_info

    def get_sections(self) -> Dict[str, ResumeSection]:
        sections = {}
        for key, section in self.doc["Sections"].items():
            sections[key] = ResumeSection(key, section)

        return sections


def read_me_file(path: str = "me.yaml") -> MeFile:
    return MeFile(path)
