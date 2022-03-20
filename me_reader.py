from xml.dom.minidom import Document
import yaml
from typing import Dict, List
from pylatex import Document, Section, Subsection, Command, Itemize
from latex_util import DatedSubsection, create_description
from recipe import ResumeRecipe

# Represents subsections in a Me file
class ResumeSubsection:
    def __init__(self, key: str, event_obj: Dict[str, any]) -> None:
        self.key = key
        self.event_obj = event_obj

    def insert_in_doc(self, doc: Document) -> None:
        title = self.get_title()
        sectionHeader = Subsection(title)

        # Check for date range
        dateRange = self.get_date_range()
        if self.get_date_range() is not None:
            sectionHeader = DatedSubsection(title, dateRange, self.get_subtitle())

        with doc.create(sectionHeader):
            desc = self.get_description()
            if (type(desc) == list):
                create_description(doc, desc)

    def should_include(self, recipe: ResumeRecipe) -> bool:
        include_subsection = True

        if self.key.lower() in recipe.exclude_items:
            include_subsection = False
        else:
            for tag in self.get_tags():
                tag = tag.lower()
                if tag in recipe.exclude_tags and not tag in recipe.include_tags:
                    include_subsection = False
                    break

        return include_subsection

    def get_title(self) -> str:
        return self.event_obj["Title"]

    def get_subtitle(self) -> str | None:
        if "Subtitle" in self.event_obj:
            return self.event_obj["Subtitle"]

        return None

    def get_date_range(self) -> str | None:
        if "Start" in self.event_obj and "End" in self.event_obj:
            start = self.event_obj["Start"]
            end = self.event_obj["End"]
            dateRange = f"{start} - {end}"
            return dateRange

        return None

    def get_description(self) -> List[str] | str | None:
        if "Description" in self.event_obj:
            return self.event_obj["Description"]

        return None

    def get_tags(self) -> List[str]:
        if "Tags" in self.event_obj:
            return self.event_obj["Tags"]

        return []

# Represents a section within the Me file
class ResumeSection:
    def __init__(self, key: str, section_obj) -> None:
        self.key = key
        self.section_obj = section_obj

    def get_description(self) -> str | List[str] | None:
        if "Description" in self.section_obj:
            return self.section_obj["Description"]

        return None

    def get_subsections(self) -> Dict[str, ResumeSubsection] | None:
        sections = None
        if "Subsections" in self.section_obj:
            sections = {}
            for key, section in self.section_obj["Subsections"].items():
                sections[key] = ResumeSubsection(key, section)

        return sections

# Represents the data contained within a Me file
class MeFile:
    def __init__(self, path: str) -> None:
        with open(path, "r") as f:
            self.doc = yaml.safe_load(f)

    def get_name(self) -> str:
        return self.doc["Me"]["Name"]

    def get_contact_info(self) -> Dict[str,str]:
        contact_info = {}
        for key,val in self.doc["Me"].items():
            if key != "Name":
                contact_info[key] = val

        return contact_info

    def get_sections(self) -> Dict[str, ResumeSection]:
        sections = {}
        for key, section in self.doc["Sections"].items():
            sections[key] = ResumeSection(key, section)

        return sections

    def create_document(self, recipe: ResumeRecipe) -> Document:
        doc = Document(documentclass="cv", geometry_options={"margin": "0.5in"})

        # Add name/contact information
        doc.append(Command("name", self.get_name()))
        contact_info = []
        for key,val in self.get_contact_info().items():
            if not key.lower() in recipe.exclude_contact:
                contact_info.append(val)
        contact = " | ".join(contact_info)
        doc.append(Command("centerline", contact))

        for sectionName,section in self.get_sections().items():
            with doc.create(Section(sectionName)):
                # Check for top-level description
                desc = section.get_description()
                if (type(desc) == list):
                    create_description(doc, desc)

                # Check for subsections
                subsections = section.get_subsections()
                if subsections is not None:
                    for subsection in subsections.values():
                        # Check to see if the section should be included
                        if subsection.should_include(recipe):
                            subsection.insert_in_doc(doc)

        return doc

def read_me_file(path: str = "me.yaml") -> MeFile:
    return MeFile(path)

if __name__ == "__main__":
    me = read_me_file()
    print(me.get_contact_info())